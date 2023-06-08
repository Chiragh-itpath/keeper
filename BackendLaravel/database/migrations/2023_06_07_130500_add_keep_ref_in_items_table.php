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
            $table->uuid('created_by')->after('tag_id');
            $table->uuid('updated_by')->after('created_by');
            $table->uuid('keep_id')->index()->after('updated_by');
            $table->foreign('keep_id')->references('id')->on('keeps')->onDelete('no action');
        });
    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        Schema::table('items', function (Blueprint $table) {
            $table->dropForeign(['keep_id']);
            $table->dropIndex(['keep_id']);
            $table->dropColumn('created_by');
            $table->dropColumn('keep_id');
            $table->dropColumn('updated_by');
        });
    }
};
