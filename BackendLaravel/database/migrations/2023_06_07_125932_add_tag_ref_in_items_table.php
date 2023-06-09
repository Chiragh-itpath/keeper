<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    /**
     * Run the migrations.
     */
    public function up(): void
    {
        Schema::table('items', function (Blueprint $table) {
            $table->uuid('tag_id')->index()->after('discussedBy');
            $table->foreign('tag_id')->references('id')->on('tags')->onDelete('no action');
        });
    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        Schema::table('items', function (Blueprint $table) {
            $table->dropForeign(['tag_id']);
            $table->dropIndex(['tag_id']);
            $table->dropColumn('tag_id');
        });
    }
};
