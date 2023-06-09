<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\SoftDeletes;

class Project extends Model
{
    use HasFactory;
    use SoftDeletes;

    protected $fillable = [
        'id',
        'title',
        'description',
        'tag_id',
        'created_by',
        'updated_by',
    ];

    protected $dates = [
        'created_at',
        'updated_at',
        'deleted_at',
    ];

    public function tag()
    {
        return $this->belongsTo(Tag::class);
    }

    public function users()
    {
        return $this->belongsToMany(User::class);
    }

    public function keeps()
    {
        return $this->hasMany(Keep::class);
    }
}
